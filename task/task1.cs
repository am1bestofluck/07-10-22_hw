using static System.Console;
string[] fast_test= {"aspera","Сорос","12321","456654","0123"};
Mirrored_string.todo();
foreach(string var in fast_test){
    Mirrored_string run= new Mirrored_string(self:var);
    run.main();
}

Mirrored_string abc= new Mirrored_string(self:"qweewq");
abc.main();
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
        int _len =1;
        while (num_parsed%Math.Pow(10,_len)!=num_parsed)
        {
            _len++;
        }
        int index_top=0,index_bottom=_len-1,supval_t,supval_b,_pow_t,_pow_b,num_top=-1,num_bottom=-2;
        _pow_t=_len;
        _pow_b=_len;
        supval_t=num_parsed;
        supval_b=num_parsed;
        while (index_top<index_bottom)
        {
            while (supval_t>Math.Pow(10,index_bottom))
            {
                supval_t=supval_t%(int)Math.Pow(10,_pow_t);
                _pow_t--;
                // Console.WriteLine(supval_t);
            }
            num_top=(int)(supval_t/Math.Pow(10,_pow_t));
            while (supval_b>Math.Pow(10,index_top))
            {
                supval_b=supval_b%(int)Math.Pow(10,_pow_b);
                _pow_b--;
            }
            num_bottom=(int)(supval_b/Math.Pow(10,_pow_t));
            index_top++;
            index_bottom--;
        }
        if (num_top!=num_bottom)
        {
            output=false;
            return output;
        }

        //...чем дальше в лес тем больше допущений.
        // 987654->10*6-- max_n znakov
        // n-1:
        // int m=987654
        // while (m>10**n-1) {m=m%10**max_n
        // max_n=max_n-1}
        // m=m/10**max_n
        // повторяем это для индексов которые идут на встречу друг другу пока они не разминутся
        // while (true){
        //     System.Console.WriteLine();
        // }
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