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
    bool math_solution(){
        bool output=true;
        int _len =content.Length;
        //всё равно надо ходить по разрядам.
        //     position=abs(position)
        // shortcut=f"{incoming_data['num']}" if incoming_data["positive"] else f"-{incoming_data['num']}"
        // shortcut_int=int(incoming_data['num'])
        // if len(incoming_data["num"])<=position:
        //     print(f"Число {shortcut} не содержит в себе {str(position+1)} знаков.")
        //     return
        // # cтрока
        // _char=incoming_data['num'][position]#женюсь.
        // # матчасть
        // #как найти первый знак? нужно число поделить на нижний разряд
        // sc_len=len(incoming_data['num'])
        // max_pow=len(incoming_data['num'])-1
        // match position:
        //     case 0:
        //         shortcut_int=shortcut_int//10**(max_pow)
        //     case _:
        //         stop_here=10**(sc_len-position)
        //         while shortcut_int>stop_here:
        //             shortcut_int=shortcut_int%10**max_pow
        //             max_pow-=1
        //             # print(shortcut_int)
        //         shortcut_int=int(shortcut_int//(stop_here/10))
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
            bool sol2= iteration_.math_solution();
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