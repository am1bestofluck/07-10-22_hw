from math import sqrt
class Point_3d:
    def __init__(self,coord_x:int,coord_y:int,coord_z:int)->None:
        self.x=coord_x
        self.y=coord_y
        self.z=coord_z
    def __repr__(self) -> str:
        return f"[{str(self.x)}, {str(self.y)}, {str(self.z)}]"
    def get_range_to(self,another_Point_3d)->float:
        assert isinstance(another_Point_3d,type(self))#а как иначе :(
        return round(
            sqrt(
                (self.x-another_Point_3d.x)**2+
                (self.y-another_Point_3d.y)**2+
                (self.z-another_Point_3d.z)**2

            ),2)



def main():
    run={
        (3,6,8):(2,1,-7),
        (7,-5, 0):(1,-1,9)
        }
    for example in run:
        # print(example)
        # print(run[example])
        p_a=Point_3d(
            example[0],example[1],example[2])
        p_b=Point_3d(
            run[example][0],run[example][1],run[example][2]
        )#хмммм. Теперь уже такая запись кажется странной.
        print(f"Расстояние от точки {p_a} до {p_b}: {str(p_a.get_range_to(p_b))}")
if __name__=="__main__":
    print("В принципе можно вызвать main(), но лучше запустить head.py")
