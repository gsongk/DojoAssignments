# Coin Tosses - finished

import random

def coin():
    head = 0
    tail = 0
    for i in range(1, 5001):
        num = random.random()
        # if a number is about to be rounded, then head
        if num >0.5:
            head = head + 1
            print "Attempt #", i, "Throwing a coin... It's a head... Got ", head,"head(s) so far and", tail, "tail(s) so far"
        # else tail
        elif num<0.5:
            tail = tail + 1
            print "Attempt #", i, "Throwing a coin... It's a tail... Got ", head,"head(s) so far and", tail, "tail(s) so far"
coin()