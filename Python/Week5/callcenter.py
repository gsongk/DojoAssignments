# Assignment: Call Center
# You're creating a program for a call center. Every time a call comes in you need a way to track 
# that call. One of your program's requirements is to store calls in a queue while callers 
# wait to speak with a call center employee.
from datetime import datetime


class call():
    def __init__(self, id, cname, cphone, time, reason):
        self.id = id
        self.cname = cname
        self.cphone = cphone
        self.time = time
        self.reason = reason

    def display(self):
        print 'ID: ' + str(self.id)
        print 'Name: ' + str(self.cname)
        print 'Phone Number: ' + str(self.cphone)
        print 'Time: ' + str(self.time)
        print 'Reason: ' + str(self.reason)


class callcenter():
    def __init__(self):
        self.calls = []
        self.queue = 0

    def add(self, call):
        self.calls.append(call)
        self.queue += 1
        return self

    def remove(self, call):
        self.calls.pop(0)
        self.queue -= 1
        return self

    def delete(self, number):
        for call in self.calls:
            if call.cphone is number:
                self.calls.remove(call)
            self.queue = len(self.calls)
        return self

    def info(self):
        for call in self.calls:
            print "Name: " + call.cname + " Phone: " + call.cphone
        print  "Calls waiting: " + str(self.queue)
        return self

    def sort_by_time(self):
        self.calls = sorted(
            self.calls, key=lambda call: call.time, reverse=True)


call1 = call(1, 'Jim', "123-4567", datetime.now(), "ARGH!")
call2 = call(2, 'Tim', "456-7890",  datetime.now(), "Call me back! It's Urgent")
call3 = call(3, 'Kim', '789-0123', datetime.now(), 'Monster!')

# call1.display()
# call2.display()
# call3.display()

desperate = callcenter()
desperate.add(call1).add(call2).add(call3).info()
desperate.remove(call2).info().delete('123-4567').info()