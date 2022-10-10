## Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
|i|o|
|:-|-:|
14212|нет
12821|да
23432|да  
* Принимаем ввод, проверяем на число.  
Если не число: только строковый метод
* строковый метод
    * задаем края : длина-1, 0
    * пока левый край меньше правого:
        * Если символы по индексам не совпали: возвращаем что не паллиндром
    * возвращаем паллиндром
* расчетный метод
    * находим разрядность, дальше по старой схеме...
     <!--
    sc_len=len(incoming_data['num'])
    max_pow=len(incoming_data['num'])-1
    match position:
        case 0:
            shortcut_int=shortcut_int//10**(max_pow)
        case _:
            stop_here=10**(sc_len-position)
            while shortcut_int>stop_here:
                shortcut_int=shortcut_int%10**max_pow
                max_pow-=1
                # print(shortcut_int)
            shortcut_int=int(shortcut_int//(stop_here/10)) -->