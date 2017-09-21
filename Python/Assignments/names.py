# Assignment: Names


students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]

users = {
 'Students': [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }

# part I
def show_students(arr):
    for x in students:
        print x['first_name'], x['last_name']

# show_students(students)

# part II

def all(arr):
    for y in users:
        print y #Prints out the title Students and Instructors
        count = 0
        for people in users[y]:
            count += 1
            # print people #Prints out the list of students and instructors
            fname = len(people['first_name'])
            lname = len(people['last_name'])
            total = fname + lname
            print count, people['first_name'], people['last_name'], total
            
all(users)