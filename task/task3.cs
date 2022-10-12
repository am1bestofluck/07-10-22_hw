using static System.Console;
class hand_drawn_table{
    string key_header;
    string value_header;
    hand_drawn_table (string key_name, string value_name){//декларирируем шапку таблицы
        key_header=(key_name==null?" x ":key_name);
        value_header=(value_name==null?" f(x) ":value_name);
    }
    public static void todo()
    {
        WriteLine("## Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.");
    }
    public static int take_and_verify_input()//проверяем предел таблицы в нашем кейсе
    {
        bool isWrong=true;
        int output_num=0;
        int limit_l=-1291,limit_u=1291;
        string buffer=String.Empty;
        while (isWrong)
        {
            WriteLine("дай число плз, целое и не больше +/-1291, потому что переполнение int32");
            buffer=ReadLine();
            isWrong=Int32.TryParse(buffer,out output_num);
            if ( (output_num>limit_l) && (output_num<limit_u) )
            {
                isWrong=true;
            }
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
    protected static Dictionary<int,int> compile_elements(int lineup_limit)//изменяемая часть. Алгоритм заполнения
    {
        Dictionary<int,int> output_dict = new Dictionary<int, int>();
        int symbols_in_key=get_number_lenght(lineup_limit),
        symbols_in_value=get_number_lenght((int)(Math.Pow(lineup_limit,3)));
        for (int i = 1; i!=lineup_limit; i=i+step_direction(1,lineup_limit))
        {
            output_dict.Add(i,(int)(Math.Pow(i,3)));    
        }
        return output_dict;
    }
    public dynamic actually_draw_table(Dictionary<int,int> _data)//cюда вернемся когда всё готово
    {

    } 
    public static void main()
    {

    }
}