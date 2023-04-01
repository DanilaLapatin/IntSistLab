//Класс нейронной сети
public class NeuralNetwork
{
    // Слои
    public Layer[] Layers;
    // Входной слой
    public Layer Input => Layers.First();
    // Выходной слой
    public Layer Output => Layers.Last();
    // Коэфф обучения
    public double LearningRate = 0.01;
    public double Activation(double x) { return 1 / (1 + Math.Exp(-x)); }         // Активационная функция
    public double Derivative(double x) { return x * (1 - x); }                  // Производня активационной функции


    public NeuralNetwork(int[] size)
    {
        // Инициализируем слои
        Layers = new Layer[size.Length];
        for (int i = 0; i < size.Length; i++)
        {
            Layers[i] = new Layer(); //инициализация слоя
            int next_size = 0;
            if (i + 1 < size.Length) next_size = size[i + 1];  //закос о будущем слое
            Layers[i].Init(size[i], next_size); //инициализация слоёв
        }
    }

    public void Work()
    { //newLrs-новый слой   lstLrs-предыдущий слой  curNeur-нейроны нового слоя
      // Для каждого нейрона в каждом слое расчитываем выходное значение
        for (int i = 1; i < Layers.Length; i++)
        {
            var curLrs = Layers[i]; //новый слой
            var prevLrs = Layers[i - 1]; //предыдущий слой

            for (int k = 0; k < curLrs.Size; k++)
            {
                var curNeur = curLrs.Neurons[k];  //нейроны нынешнего слоя
                for (int j = 0; j < prevLrs.Size; j++)
                {
                    curNeur.Output += prevLrs.Weights[j][k] * prevLrs.Neurons[j].Output; //(w*x) получаем сумму
                }
                curNeur.Output += curNeur.Base; //+b
                curNeur.Output = Activation(curNeur.Output); //преобразователь выхода сумматора 
            }
        }
    }

    // Очистка выходных значений
    public void Clear()
    {
        foreach (var l in Layers)
        {
            foreach (var n in l.Neurons)
            {
                n.Output = 0;
            }
        }
    }

    // Обучение на основе алгоритма обратного распространения ошибки
    public void BackPropagation(double[] targets)
    {
        double[] errors = new double[Output.Size];
        for (int i = 0; i < Output.Size; i++)
        {
            errors[i] = targets[i] - Output.Neurons[i].Output; //отклонение от реальных значений
        }
        for (int k = Layers.Length - 2; k >= 0; k--)
        {
            Layer prevLrs = Layers[k];
            Layer curLrs = Layers[k + 1];
            double[] errorsNext = new double[prevLrs.Size]; //для следующего слоя
            double[] gradients = new double[curLrs.Size];
            for (int i = 0; i < curLrs.Size; i++) //вычисление градиента
            {
                gradients[i] = errors[i] * Derivative(curLrs.Neurons[i].Output);
                gradients[i] *= LearningRate;
            }
            double[][] deltas = new double[curLrs.Size][];
            for (int i = 0; i < curLrs.Size; i++)
            {
                deltas[i] = new double[prevLrs.Size];
                for (int j = 0; j < prevLrs.Size; j++)
                {
                    deltas[i][j] = gradients[i] * prevLrs.Neurons[j].Output; //значение ошибки нейрона
                }
            }
            for (int i = 0; i < prevLrs.Size; i++)
            {
                errorsNext[i] = 0;
                for (int j = 0; j < curLrs.Size; j++)
                {
                    errorsNext[i] += prevLrs.Weights[i][j] * errors[j];
                }
            }
            errors = new double[prevLrs.Size];
            errorsNext.CopyTo(errors, 0);
            double[][] weightsNew = new double[prevLrs.Size][];
            for (int i = 0; i < prevLrs.Size; i++)
                weightsNew[i] = new double[curLrs.Size];
            for (int i = 0; i < curLrs.Size; i++)
            {
                for (int j = 0; j < prevLrs.Size; j++)
                {
                    weightsNew[j][i] = prevLrs.Weights[j][i] + deltas[i][j]; //коррекция весов связей ИНС
                }
            }

            prevLrs.Weights = weightsNew; //Замена весов

            for (int i = 0; i < curLrs.Size; i++)
            {
                curLrs.Neurons[i].Base += gradients[i]; //Настройка смещения нейронов
            }
        }
    }
}