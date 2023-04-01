public class Neuron
{
    //Выходное значение
    public double Output;
    //Базис
    public double Base;
}

public class Layer
{
    //Размер слоя
    public int Size;
    //Нейроны
    public Neuron[] Neurons;
    //Веса
    public double[][] Weights;

    public Layer() { }

    //Инициализируем слой, задаем кол-во нейронов
    public void Init(int size, int next)
    {
        Size = size;
        Neurons = new Neuron[size];
        Weights = new double[size][];

        for (int i = 0; i < size; i++)
        {
            Neurons[i] = new Neuron();
            Weights[i] = new double[next];
        }
    }
}