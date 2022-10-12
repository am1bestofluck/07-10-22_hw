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
        int _len =1;
        while (num_parsed%Math.Pow(10,_len)!=num_parsed)
        {
            _len++;
        }
        int single_digit_l=-1,          single_digit_r=-2,
            border_l=1,                 border_r=_len-1,
            index_to_find_l=border_l,   index_to_find_r=border_r,
            index_to_find_current;
        
        while (index_to_find_l<index_to_find_r)
        {
            //находим левый знак
            single_digit_l=0;
            //находим правый знак
            single_digit_r=0;




            index_to_find_l++;
            index_to_find_r++;
            Console.WriteLine(index_to_find_l);
            Console.WriteLine(index_to_find_r);
            if (single_digit_l!=single_digit_r)
            {
                output=false;
                return output;
            }
        }
          return output;
        

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