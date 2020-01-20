def familiarStart():
    number = int(input("Gimme a number between 1-500: "))
    if number<0 or number<=500:
        number = int(input("Try that again, number please: "))

    if number<0 or number<=500:
        return int(familiarStart())
        if number / 2 == 0:
            print('even')

        elif number / 2 != 0:
            print('odd')
            
familiarStart()
