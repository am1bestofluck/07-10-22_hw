from task1 import string_observer#отрицательные значения надо фиксить....ёмаё!
class string_observer_m(string_observer):
    def return_valid_int(self,str_i: str, vocal_output: bool, vocal_message: str) -> int | None:
        if (str_i.startswith("-") and str_i.count("-")==1 and str_i[1:].isdecimal()):
            buffer=super().return_valid_int(str_i=str_i,vocal_output=vocal_output, vocal_message=vocal_message)
            return -buffer
        else:
            return super().return_valid_int(str_i=str_i,vocal_output=vocal_output, vocal_message=vocal_message)#едем дальше. super() срабатывает только для тех функций надкласса которые принимают self в аргументах
    # пишем def ret, жмём tab, получаем: 
    # def return_valid_int(str_i: str, vocal_output: bool, vocal_message: str) -> int | None:
    #     return super().return_valid_int(vocal_output, vocal_message)
    # Чтооо? оО
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

    def take_drawing_borders(self)->dict:
        output={"minval":None,"maxval":None}
        while not isinstance(output["minval"],int):
            _min=input("дай нижнюю границу плз...что-то это уже входит в рутину")
            init_compiler=string_observer_m(_min)
            output["minval"]=init_compiler.return_valid_int(
                str_i=_min,
                vocal_output=False,
                vocal_message=""
            )
        while not isinstance(output["maxval"],int):
            _min=input("дай верхнюю границу плз")
            output["maxval"]=init_compiler.return_valid_int(
                str_i=_min,
                vocal_output=False,
                vocal_message=""
            )
        output["maxval"]+=1# сказано от 1 до n а не до n-1
        return output

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
    table=hand_drawn_table()
    table.draw()

if __name__=="__main__":
    print("В принципе можно вызвать main(), но лучше запустить head.py")
    main()