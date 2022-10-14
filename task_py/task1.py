class string_observer:
    def __init__(self,obj:str):
        assert isinstance(obj,str)
        self.__obj=obj
    def new_arg(self,new_obj:str):
        self.__obj=new_obj
    def shout_out(self)->None:
        print(f"Текущий аргумент:{self.__obj}")
    def todo():
        __task="## Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом."
        print(__task)
    def __core_str(self)->None:
        index={"first":0,"final":len(self.__obj)-1}
        is_valid=True
        self.__obj_lowercased=self.__obj.lower()
        while index["first"]<index["final"]:
            if self.__obj_lowercased[index["first"]]!=self.__obj_lowercased[index["final"]]:
                is_valid=False
                break
            index["first"]+=1
            index["final"]-=1
        print("Строчное решение: Это паллиндром" if is_valid else "Cтрочное решение: Это не паллиндром")
        
    def return_valid_int(str_i:str,vocal_output:bool,vocal_message:str)->int|None:#немного перекроил метод для третьей задачи
        match str_i.count("-"):
            case 0:
                if not str_i.isdecimal():
                    if vocal_output: print(vocal_message) 
                    return
                else:
                    output_num=int(str_i)
            case 1:
                if str_i.startswith("-"):
                    str_m=str_i[1:]
                    if not str_m.isdecimal():
                        print(vocal_message)
                        return
                    else:
                        output_num=int(str_m)
                else:
                    print(vocal_message)
                    return
            case _:
                print(vocal_message)
                return
        return output_num
    def __core_math(self)->None:
        output_math="Математический метод: не число, нельзя !посчитать"
        obj_int=string_observer.return_valid_int(
            str_i=self.__obj,
            vocal_output=True,
            vocal_message=output_math)
        if obj_int is None:
            return
        #дробим число на знаки
        list_digits=[]
        #находим количество знаков в числе
        pows=1
        while obj_int%10**pows!=obj_int:
            pows+=1
        #убираем сразу один разряд, потому что тавтология
        while obj_int!=0:
            list_digits.append(obj_int//10**(pows-1))
            obj_int=obj_int%10**(pows-1)
            pows-=1
        #снова идём по массиву но уже из цифр
        index_start,index_last=0,len(list_digits)-1
        while index_start<index_last:
            if list_digits[index_start]!=list_digits[index_last]:
                output_math="Математический метод: это не паллиндром"
                print(output_math)
                return
            index_start+=1
            index_last-=1
        output_math="Математический метод: это паллиндром"
        print(output_math)
        return


    def __repr__(self):
        return("Этот класс определяет зеркальность принятой строки. Двумя способами")
    def main(self):
        self.__core_str()
        self.__core_math()
def main():
    string_observer.todo()
    speaker=string_observer("")
    quick_test=["aspera","Сорос","12321","456654","0123","0222","2220","-00818"]
    for _next in quick_test:
        speaker.new_arg(_next)
        speaker.shout_out()
        speaker.main()
if __name__=="__main__":
    print("В принципе можно вызвать main(), но лучше запустить head.py")
    main()