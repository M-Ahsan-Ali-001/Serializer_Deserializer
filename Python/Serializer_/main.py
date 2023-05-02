import pickle

path = "dang.pkl"
class customer:
    def __init__(self, name,password):
        self.name =name
        self.password =password

def Obj_maker(name , passw):
    obj =  customer(name , passw)
    with open (path , 'ab') as inputfile:
        pickle.dump(obj,inputfile)

def Deserializer():
    with open(path, 'rb') as outfile:
        while True:
            try:
                obj = pickle.load(outfile)
                for key, value in obj.__dict__.items():
                    print(f"{key}: {value}")
                print()  # print a blank line between objects
            except EOFError:
                break



if __name__ == '__main__':

  # Obj_maker("ahsan" , "1234dDaads$")
  # Obj_maker("player1" , "123ds$")
   Deserializer()




