using static System.Console;
WriteLine("первое задание:\n");
string[] fast_test= {"aspera","Сорос","12321","456654","0123","0222","2220","-00818"};
Mirrored_string.todo();
foreach(string var in fast_test){
    Mirrored_string run= new Mirrored_string(self:var);
    run.main();
}
WriteLine("\nВторое задание:\n\n");
Point_3d.homework_check();
WriteLine("\nТретье задание:\n\n");
hand_drawn_table.main();