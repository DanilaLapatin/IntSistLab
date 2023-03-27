// IntSystLab3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <ctime>

using namespace std;

class CreatureV //Особь с генами X, Y
{
public:
    double X, Y;
    //формирование начальной популяции
    CreatureV()
    {
        X = (double)rand() - (double)rand();
        func(X);
    };
    //оценка функции
    void func(double x) {
        Y = x * x + 4;
    }
    //оператор сравнения
    bool operator>(CreatureV& P2)
    {
        if (this->Y > P2.Y) return true;
        else return false;
    }
};

class PopulationV //Популяция с массивом Особей
{
    int size;
    CreatureV* Array;
public:

    //формирование начальной популяции
    PopulationV(int n)
    {
        size = n;
        Array = new CreatureV[size];
    }
    //оператор индексации
    CreatureV& operator[](int n)
    {
        return Array[n];
    }

};

class GeneticAlgorithmV
{
    int size = 100; //начальный размер популяции
    int count = size; //текущий размер популяции
    PopulationV A = PopulationV(size); //Формирование популяции
public:
    CreatureV Algorithm() //Основной алгоритм
    {
        int i, max_i = 100;
        for (i = 0; i < max_i; i++) // Количество итераций
        {
            Crossing(); //Скрещивание
            Mutation(); //Мутация
            Sort(); //Сортировка и расчет приспособленности
            Selection(); //Селекция усечением
            if (abs(A[0].Y - A[count].Y) <= 0.001) break; //Оценивание популяции
        }
        return A[0];
    }

    void Sort() 
    {
        int i, j, h;
        CreatureV temp;
        for (i = 0; i < count; i++) //расчет приспособленности
            A[i].func(A[i].X);
        for (h = 1; h <= count / 9; h = h * 3 + 1); //сортировка Шелла
        while (h >= 1)
        {
            for (i = h; i < count; i++)
                for (j = i - h; j >= 0 and A[j].Y > A[j + h].Y; j -= h)
                {
                    temp = A[j];
                    A[j] = A[j + h];
                    A[j + h] = temp;
                }
            h = (h - 1) / 3;
        }
    }

    void Selection()
    {
        double l = 0.5; //порог отсечения
        for (int i = size - 1; i > (l * size); i--) //очищение наименее приспособленных особей
        {
            A[i].X = 0;
            A[i].Y = 0;
            count--;
        }
    }


    void Crossing()
    {
        int old_size = count; //Для формирования потомков
        double p = 0.9; //Вероятность скрещивания
        while (count < size) //Восстановление количества потомков
        {
            int i = (int)(rand() % old_size);
            int j = (int)(rand() % old_size);
            double lambda = rand() % 10 * 0.01;
            if (p > (rand() % 10) * 0.01) //Скрещивание с вероятностью Р
            {//арифметический кроссинговер
                A[count++].X = lambda * A[i].X + (1 - lambda) * A[j].X;
                A[count++].X = lambda * A[j].X + (1 - lambda) * A[i].X;
            }
        }
        count--;
    }

    void Mutation()
    {
        double mutate = 0.25; //вероятность мутации
        for (int i = 0; i < count; i++)
        {
            if (mutate > rand() % 100 * 0.01)
            {
                A[i].X += (((double)rand() / RAND_MAX) - 0.3) * 100; //от -30 до 30
            }
        }
    }
};


using namespace std;

class Creature//Особь с генами X, Y
{
    int xmin = -10;
    int xmax = 10;
public:
    double X, Y;
    bool* string;
    int size = 10;//разрядность

    Creature()
    {
        string = new bool[size];

        for (int i = 0; i < size; i++)
        {
            string[i] = rand() % 2;
        }
    };

    void decode()
    {
        double value, razryad2;
        value = 0.0;

        razryad2 = 1;

        for (int j = size - 1; j >= 0; j--)

        {
            if (string[j])   value = value + razryad2;

            razryad2 = razryad2 * 2;
        }

        X = xmin + (xmax - xmin) * value / (razryad2 - 1);
        Y = X * X + 4;
    };

    friend ostream& operator<<(ostream& stream, Creature& obj)
    {
        for (int i = 0; i < obj.size; i++)
            stream << obj.string[i] << " ";

        return stream;
    };
};

class Population //Популяция с массивом Особей
{
    int size;
    Creature* Array;
public:

    Population(int n)
    {
        size = n;
        Array = new Creature[size];
    }

    Creature& operator[](int n)
    {
        return Array[n];
    }

    friend ostream& operator<<(ostream& stream, Population& obj)
    {
        for (int i = 0; i < obj.size; i++)
            stream << obj.Array[i] << endl;
        return stream;
    };

};

class GeneticAlgorithm
{
    int size = 1000; //размер начальной популяции
    int count = size; //текущий размер популяции
    Population A = Population(size); //формирование популяции

public:
    Creature Algorithm() //Основной алгоритм
    {
        int i, max_i = 1;
        for (i = 0; i < max_i; i++) // Количество итераций
        {
            Crossing(); //Скрещивание
            Mutation(); //Мутация
            Sort(); //Сортировка и рассчет приспособленности
            Selection(); //Селекция усечением
            if (abs(A[0].Y - A[count].Y) <= 0.001) break; //Оценивание популяции
        }
        return A[0];
    }

    double func(double x)
    {
        return x * x + 4;
    }

    void Sort()
    {
        int i, j, h;
        for (i = 0; i < count; i++)
            A[i].Y = func(A[i].X); // рассчет приспособенности
        for (h = 1; h <= count / 9; h = h * 3 + 1); //сортировка Шелла
        while (h >= 1)
        {
            for (i = h; i < count; i++)
                for (j = i - h; j >= 0 and A[j].Y > A[j + h].Y; j -= h)
                {
                    Creature temp = A[j];
                    A[j] = A[j + h];
                    A[j + h] = temp;
                }
            h = (h - 1) / 3;
        }
    }

    void Selection()
    {
        double l = 0.5; //порог отсечения
        for (int i = size - 1; i > (l * size); i--) //очищение наименее приспособленных особей
        {
            for (int j = 0; j < 10; j++)
            {
                A[i].string[j] = 0;
            }

            A[i].decode();
            count--;
        }
    }

    void Crossing()
    {
        int cut = rand() % (10 - 2) + 1;// случайная точка разрыва 
        double p = 0.9; //Вероятность скрещивания
        int old_size = count; //Для формирования потомков

        while (count < size) //Восстановление количества потомков
        {
            int i = (int)(rand() % old_size);
            int j = (int)(rand() % old_size);

            if (p > (rand() % 10) * 0.01) // вероятность скрещивания
            {
                for (int r = 0; r < cut; r++) // гены до 1 точки разрыва
                {
                    A[count].string[r] = A[i].string[r];
                }
                for (int t = cut; t < 10; t++) // гены до 1 точки разрыва
                {
                    A[count].string[t] = A[j].string[t];
                }

                A[count].decode();
                count++;
            }
        }
    };

    void Mutation()
    {
        double mutate = 0.25; //вероятность мутации

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (mutate > rand() % 100 * 0.01)
                {
                    A[i].string[j] = !A[i].string[j];
                }
            }
            A[i].decode();
        }
    };
};



int main()
{
    srand(time(0));
    GeneticAlgorithm GA;
    Creature result = GA.Algorithm();
    cout << "f(x) = x * x + 4" << endl;
    cout << "Xmin = " << result.X << " Ymin = " << result.Y << endl;
    GeneticAlgorithmV GAV;
    CreatureV resultV = GAV.Algorithm();
    cout << "f(x) = x * x + 4" << endl;
    cout << "Xmin = " << resultV.X << " Ymin = " << resultV.Y << endl;

}


// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
