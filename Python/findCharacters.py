# Find Characters

def find(word_list, char):
    new_list = []
    for i in range(0, len(word_list)):
        if word_list[i].find(char) != -1:
            new_list.append(word_list[i])

    print new_list

#input
word_list = ['hello', 'world', 'my', 'is', 'Anna']
char = 'o'

find(word_list, char)