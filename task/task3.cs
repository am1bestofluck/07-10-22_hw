using static System.Console;
class hand_drawn_table{
    string key_header=" x ";
    string value_header=" f(x) ";
    public hand_drawn_table (string key_name, string value_name){//декларирируем шапку таблицы
        key_header=(key_name==null?" x ":key_name);
        value_header=(value_name==null?" f(x) ":value_name);
    }
    public hand_drawn_table()
    {
        this.key_header=key_header;
        this.value_header=value_header;
    }
    public static void todo()
    {
        WriteLine("## Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.");
    }
    public static int take_and_verify_input(string note,bool upper_limit)//проверяем предел таблицы в нашем кейсе
    {
        WriteLine(note);
        bool isValid=false;
        int output_num=0;
        int limit_l=-1291,limit_u=1291;
        string buffer=String.Empty;
        while (isValid==false)
        {
            WriteLine("дай число плз, целое и не больше +/-1291, потому что переполнение int32");
            buffer=ReadLine();
            isValid=Int32.TryParse(buffer,out output_num);
            if (isValid==true)
            {

            
            if ( (output_num<limit_l) || (output_num>limit_u) )
            {
                isValid=false;
            }
            }
        }
        if (upper_limit)
        {
            output_num++;
        }
        return output_num;
    }
    public static int get_number_lenght(int number)//кол-во символов в числе
    {
        int output=1;
        while (number%(int)(Math.Pow(10,output))!=number)
        {
            output++;
        }
        return output;
    }
    protected static int step_direction(int walk_start, int walk_goal)//направление шага для for
    {
        int step=0;
        switch (walk_start>walk_goal)
        {
            case true:
            {
                step=-1;
                break;//мдааааа, ну это конечно та ещё зая. Оказывается break это !!обязательный
                // элемент синтаксиса... 
            }
            case false:
            {
                step=1;
                break;
            }
            default:
            {
                throw new InvalidDataException("Мы уже там где надо.");
            }
        }
        return step;
    }
    protected static Dictionary<int,int> compile_elements(int lineup_limit,int lineup_start)//изменяемая часть. Алгоритм заполнения
    {
        Dictionary<int,int> output_dict = new Dictionary<int, int>();
        int symbols_in_key=get_number_lenght(lineup_limit),
        symbols_in_value=get_number_lenght((int)(Math.Pow(lineup_limit,3)));
        for (int i = lineup_start; i!=lineup_limit; i=i+step_direction(1,lineup_limit))
        {
            output_dict.Add(i,(int)(Math.Pow(i,3)));    
        }
        return output_dict;
    }
    public dynamic actually_draw_table(Dictionary<int,int> _data,int border_upper,int border_lower)//cюда вернемся когда всё готово
    {
        //определяемся с шириной столбцов
        // string equalizer=String.Empty; костыли не нужны, есть String.PadRight
        string decorator_left="| ",decorator_mid=" | ",decorator_right=" |";
        int offset= decorator_left.Length+decorator_right.Length+decorator_mid.Length;
        int _len_key=get_number_lenght(border_upper);
        if (_len_key<this.key_header.Length)
        {
            _len_key=this.key_header.Length;
        }
        _len_key=_len_key+1;//...фиксим отрицательные кубы
        int _len_value=get_number_lenght(border_upper*border_upper*border_upper);//что-то говорили на семинаре на счёт
        //  того что math.pow использовать нельзя....ну лаааадно.
        _len_value=_len_value+1;//...фиксим отрицательные кубы
        string drawline=String.Empty;
        for (int i = 0; i < (_len_key+_len_value+offset); i++)
        {
            drawline=drawline+"-";
        }//_len_key+_len_value+offset
        //рисуем^^
        WriteLine(drawline);
        WriteLine(decorator_left+this.key_header.PadRight(_len_key)+
        decorator_mid+this.value_header.PadRight(_len_value)+decorator_right);
        WriteLine(drawline);
        foreach (KeyValuePair<int,int> pair in _data)
        {
            WriteLine(decorator_left+pair.Key.ToString().PadRight(_len_key)+
            decorator_mid+pair.Value.ToString().PadRight(_len_value)+decorator_right);
        }
        WriteLine(drawline);
        return null;//потому что dynamic оказывается должен что-то отдать
    } 
    public static void main()
    {
        todo();
        hand_drawn_table pretty_table = new hand_drawn_table();
        int start_walk=take_and_verify_input(note:"Откуда начинаем шагать?",upper_limit:false); 
        int finish_walk=take_and_verify_input(note:"Куда идём?",upper_limit:true);//...кошмар.
        Dictionary <int,int> content= compile_elements(lineup_start:start_walk,lineup_limit:finish_walk);
        pretty_table.actually_draw_table(_data:content,border_lower:start_walk,border_upper:finish_walk);
    }
}