    class Program
    {
        static NeuralNetwork MyNetwork;
        static readonly Random rnd = new Random((int)DateTime.Now.Ticks);

        static void Main()
        {
            //Задаем кол-во слоев и нейронов
            var size = new int[] { 3, 3, 3, 3 }; //4 слоя с 3 нейронами
            MyNetwork = new NeuralNetwork(size);            //Создаем нейронную сеть
            //Заполняем нейроны начальными данными
            foreach (var l in MyNetwork.Layers) //в каждом нейроне каждого слоя заполняем base
            {
                foreach (var n in l.Neurons)
                {
                    n.Base = rnd.NextDouble() * 2 - 1; //base от -1 до 1
                }
            }
            for (int i = 1; i < MyNetwork.Layers.Length; i++) //weight от -1 до 1
            {
                for (int j = 0; j < MyNetwork.Layers[i].Weights.Length; j++)
                {
                    for (int k = 0; k < MyNetwork.Layers[i].Weights[j].Length; k++)
                        MyNetwork.Layers[i].Weights[j][k] = rnd.NextDouble() * 2 - 1;
                }
            }
            //Производим 100,000 итераций обучения
            for (int i = 0; i < 100000; i++) Learning();
            while (true)             //Работаем с нейронной сетью
            {
                //Вводим три параметра
                Console.WriteLine("Input 3 parametrs(0, 1): ");
                for (int i = 0; i < MyNetwork.Input.Size; i++)
                {
                    //Задаем значения входных
                    MyNetwork.Input.Neurons[i].Output = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Results: {MyNetwork.Input.Neurons[0].Output} {MyNetwork.Input.Neurons[1].Output} {MyNetwork.Input.Neurons[2].Output}");
                //Начинаем работу
                MyNetwork.Work();
                //Выводим результат из выходных нейронов
                int max = 0;
                for (int i = 1; i < MyNetwork.Output.Size; i++)
                {
                    if (MyNetwork.Output.Neurons[max].Output < MyNetwork.Output.Neurons[i].Output) max = i;
                }
                //Console.WriteLine($"Class: {max + 1}= {MyNetwork.Output.Neurons[max].Output}\n");
                Console.WriteLine($"Class: {max + 1}\n");
                MyNetwork.Clear();
            }
        }

        static void Learning() //обучение на входных данных
        {   //задаем входные нейроны
            MyNetwork.Input.Neurons[0].Output = 1; MyNetwork.Input.Neurons[1].Output = 1; MyNetwork.Input.Neurons[2].Output = 0;
            var target = new double[] { 1, 0, 0 }; //цель обучения
            MyNetwork.Work(); //Начало обучения
            MyNetwork.BackPropagation(target); //Расчет новых весов нейронов используя алгоритм обратного распространения ошибки
            MyNetwork.Input.Neurons[0].Output = 1; MyNetwork.Input.Neurons[1].Output = 0; MyNetwork.Input.Neurons[2].Output = 1;
            target = new double[] { 1, 0, 0 };
            MyNetwork.Work();
            MyNetwork.BackPropagation(target);
            MyNetwork.Input.Neurons[0].Output = 0; MyNetwork.Input.Neurons[1].Output = 1; MyNetwork.Input.Neurons[2].Output = 1;
            target = new double[] { 0, 1, 0 };
            MyNetwork.Work();
            MyNetwork.BackPropagation(target);
            MyNetwork.Input.Neurons[0].Output = 0; MyNetwork.Input.Neurons[1].Output = 1; MyNetwork.Input.Neurons[2].Output = 0;
            target = new double[] { 0, 0, 1 };
            MyNetwork.Work();
            MyNetwork.BackPropagation(target);
            MyNetwork.Input.Neurons[0].Output = 0; MyNetwork.Input.Neurons[1].Output = 0; MyNetwork.Input.Neurons[2].Output = 1;
            target = new double[] { 0, 0, 1 };
            MyNetwork.Work();
            MyNetwork.BackPropagation(target);
            MyNetwork.Input.Neurons[0].Output = 0; MyNetwork.Input.Neurons[1].Output = 1; MyNetwork.Input.Neurons[2].Output = 0;
            target = new double[] { 0, 0, 1 };
            MyNetwork.Work();
            MyNetwork.BackPropagation(target);
            MyNetwork.Input.Neurons[0].Output = 1; MyNetwork.Input.Neurons[1].Output = 1; MyNetwork.Input.Neurons[2].Output = 1;
            target = new double[] { 1, 0, 0 };
            MyNetwork.Work();
            MyNetwork.BackPropagation(target);
            MyNetwork.Input.Neurons[0].Output = 0; MyNetwork.Input.Neurons[1].Output = 0; MyNetwork.Input.Neurons[2].Output = 0;
            target = new double[] { 0, 1, 0 };
            MyNetwork.Work();
            MyNetwork.BackPropagation(target);
        }
    }
