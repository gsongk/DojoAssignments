# Assignment: MathDojo
# HINT: To do this exercise, you will probably have to use 'return self'. 
# If the method returns itself (an instance of itself), we can chain methods.

class MathDojo(object):
    def __init__(self):
        self.result = 0
        self.addition = 0
        self.subtraction = 0

    def add(self, *args):
        for x in args:
            if type(x) == list or type(x) == tuple:
                for y in x:
                    self.addition += y
            else:
                self.addition += x
        return self

    def subtract(self, *args):
        for x in args:
            if type(x) == list or type(x) == tuple:
                for y in x:
                    self.subtraction += y
            else:
                self.subtraction += x
        return self

    def total(self):
        self.result += self.addition - self.subtraction
        print ' Answer: {}'.format(self.result)


md1 = MathDojo()
md1.add(2).add(2, 5).subtract(3, 2).total()

md2 = MathDojo()
md2.add([1], 3, 4).add([3, 5, 7, 8], [2, 4.3, 1.25]).subtract(2, [2, 3], [1.1, 2.3]).total()
