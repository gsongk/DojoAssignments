# Scores and Grades - finished

import random
random_num = random.randint(0,100)

def grade ():
    if random_num < 60:
        print "Score:", random_num, "Your grade is F"
    elif random_num >60 and random_num<69:
        print "Score:", random_num, "Your grade is D"
    elif random_num >70 and random_num<79:
        print "Score:", random_num, "Your grade is C"
    elif random_num >80 and random_num<89:
        print "Score:", random_num, "Your grade is B"
    elif random_num >90 and random_num<=100:
        print "Score:", random_num, "Your grade is A"
grade()