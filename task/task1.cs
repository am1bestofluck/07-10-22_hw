using static System.Console;

class Mirrored_string{
    public static void todo(){
        WriteLine("// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.");
    }
    public string content;
    public Mirrored_string(string self){
        content=self.ToLower();//Не бывает заглавной цифры, но со строками расклад интересней.
        // И раз уж Мы хотим крыжить и строки тоже, то это надо учесть.
        // НО. С другой стороны( двери айти-компании), нужно делать только то что сказали... какая скука.
    }
    public void represent(){
        WriteLine(content);
    }
    Dictionary<bool,int> is_decimal(){
        Dictionary<bool,int> output= new Dictionary<bool, int>();
        int out_num;
        bool valid=Int32.TryParse(content,out out_num);
        output.Add(valid,out_num);
        return output;
    }
    bool string_solution(){
        bool output=true;
        int _len=content.Length, index_s=0, index_f=_len-1;
        while (index_s<index_f){
            if (content[index_s]!=content[index_f]){
                output=false;
                return output;
            }
            index_s++;
            index_f--;
        }
        return output;
    }
    bool math_solution(int num_parsed){
        bool output=true;
        // int _len =content.Length;
        int _len=1;
        while (num_parsed%(int)(Math.Pow(10,_len))!=num_parsed)
        {
            _len++;
        }
        int num_m= Math.Abs(num_parsed);//...чем дальше в лес тем больше допущений.
        //как же Я заустал.
        //сначала дробим число по символьно и ложим в новый массив.
        int[] number_divided=new int[_len];
        int temp_single_digit;
        int buffer=num_parsed;
        for (int step_backwards = _len-1,output_index=0; step_backwards >=0;step_backwards--,output_index++)
        {
        temp_single_digit=buffer/(int)(Math.Pow(10,step_backwards));
        buffer=buffer%(int)(Math.Pow(10,step_backwards));
        number_divided[output_index]=temp_single_digit;
        }
        //потом уже ходим по массиву, это же просто?
        for (int index_start=0,index_end=number_divided.Length-1; index_start<index_end; index_start++,index_end--)
        {
            if (number_divided[index_start]!=number_divided[index_end])
            {
                output=false;
                return output;
            }
        }
        return output;
    }
    public void main(){//string[] args не обязательно, это аргументы 
        // todo();
        WriteLine($"\nРассматриваем аргумент {content}");
        Mirrored_string iteration_= new Mirrored_string(content);
        bool sol1=iteration_.string_solution();
        if (sol1==true)
        {
            Console.WriteLine("Строковое решение: это паллиндром!");
        }
        else
        {
            Console.WriteLine("Строковое решение: это не паллиндром!");
        }
        Dictionary <bool,int> decimal_solution= iteration_.is_decimal();
        if (decimal_solution.First().Key==false){
            Console.WriteLine("не число, зеркальность нельзя !посчитать");
        }
        else {
            bool sol2= iteration_.math_solution(num_parsed: decimal_solution.First().Value);
            if (sol2==true){
                Console.WriteLine("Математическое решение: это паллиндром");
            }
            else
            {
                Console.WriteLine("Математическое решение: это не паллиндром");
            }

        }
    }
}


// 14212 -> нет

// 12821 -> да

// 23432 -> да

// Принимаем ввод, проверяем на число.
// строковый метод
// задаем края : длина-1, 0
// пока левый край меньше правого:
// Если символы по индексам не совпали: возвращаем что не паллиндром
// в конце цикла возвращаем паллиндром
// расчетный метод
// находим разрядность, дальше по старой схеме...