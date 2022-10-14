from task1 import string_observer

class hand_drawn_table:
    def __init__(self, header_name=None,value_name=None,lower_limit=None,upper_limit=None)->None:# оказывается, это не лень а "перегрузка функции" :))
        self.header_name="x" if header_name is None else header_name
        self.value_name="f(x)" if value_name is None else value_name
        if (lower_limit is None or not isinstance(lower_limit,int)) or\
        (upper_limit is None or not isinstance(upper_limit,int)):
            print("нет, или неполное описание границ")
            self.content_limits=self.take_drawing_borders()#пусть будет на всякий случай.
        else:
            self.content_limits={"minval":lower_limit,"maxval":upper_limit+1}

    def todo()->None:
        print("Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.")
        return

    def take_drawing_borders(self)->None:
        output={"minval":None,"maxval":None}
        while not isinstance(output["minval"],int):
            _min=input("дай нижнюю границу плз...что-то это уже входит в рутину")
            output["minval"]=string_observer.return_valid_int(
                str_i=_min,
                vocal_output=False,
                vocal_message=""
            )
        while not isinstance(output["maxval"],int):
            _min=input("дай верхнюю границу плз")
            output["maxval"]=string_observer.return_valid_int(
                str_i=_min,
                vocal_output=False,
                vocal_message=""
            )
        output["maxval"]+=1# сказано от 1 до n а не до n-1
        self.content_limits=output

    def draw(self):
        decorator={"left":"| ","mid":" | ","right":" |"}
        col_x=max(
            max(len(str(self.content_limits["minval"])),len(str(self.content_limits["maxval"])))+1,\
            len(self.header_name)+1)
            #можно и в одну строчку конечно но код чаще читают чем пишут    
        col_fx=max(
            max(len(str(self.content_limits["minval"]**3)),len(str(self.content_limits["maxval"]**3)))+1,\
                len(self.value_name)+1)
        strikethrough="-"*(col_x+col_fx+len(decorator["left"]+decorator["mid"]+decorator["right"]))
        #поехали
        print(strikethrough)
        print(f"{decorator['left']}{self.header_name.ljust(col_x)}{decorator['mid']}{self.value_name.ljust(col_fx)}{decorator['right']}")
        print(strikethrough)
        for nextline in range(self.content_limits["minval"],self.content_limits["maxval"],1):
            print(f"{decorator['left']}{str(nextline).ljust(col_x)}{decorator['mid']}{str(nextline**3).ljust(col_fx)}{decorator['right']}")
        print(strikethrough)
def main():
    hand_drawn_table.todo()
    table=hand_drawn_table(lower_limit=-10,upper_limit=10)
    table.draw()

if __name__=="__main__":
    print("В принципе можно вызвать main(), но лучше запустить head.py")
    main()