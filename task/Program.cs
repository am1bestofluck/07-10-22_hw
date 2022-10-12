// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
string[] fast_test= {"aspera","Сорос","12321","456654","0123","0222","2220"};
Mirrored_string.todo();
foreach(string var in fast_test){
    Mirrored_string run= new Mirrored_string(self:var);
    run.main();
}