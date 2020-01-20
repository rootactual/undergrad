#Credit to Dierbach for base code prior to modification for assignment

import random

# HI
print('This program\'s purpose is to enter a number of coins to which')
print('the values add up to the displayed target value.\n')
print('Enter the values as 1-penny, 5-nickel, 10-dime, and 25-quarter')
print('with the least amount of coins used.')
print('Hit return/enter after the last entered value to check result.')
print('-------------------')

# init
terminate = False
empty_str = ''
optCoins = 0 # the goose, remember to reset later

# start
while not terminate:
# rand logic & vars
    amt  = random.randint(1,99)
    optCoins = 0
#coin logic
    cent = amt
    q = (cent // 25)
    cent = (cent % 25)
    d = (cent // 10)
    cent = (cent % 10)
    n = (cent // 5)
    cent = (cent % 5)
    p = (cent // 1)
    optCoins = q + d + n + p
    
    print('Enter optimal amount of coins that add up to', amt, 'cents, one')
    print('entry per line.\n')
    game_over = False
    tot = 0 #0's check
    cC = 0 #0's check
    
    while not game_over:
        valid_entry = False
        
        while not valid_entry:
            if tot == 0:
                ent = input('First coin: ')
                
            else:
                ent = input('Next coin value: ')
                cC = cC + 1
                
            if ent in (empty_str, '1', '5', '10', '25'):
                valid_entry = True
            else:
                print('Nope.')
                cC = cC - 1
        if ent == empty_str:
            if tot == amt:
                if int(cC) > int(optCoins):
                    print("Inefficient usage of coinage.")
                    game_over = True
                else:
                    print('Noice')
                    game_over = True
            else:
                print('Negative.  You\'ve only given', tot, 'cents.')
                game_over = True
        else:
            #uc = uc + 1
            tot = tot + int(ent)
            if tot > amt:
                print('Negative.  You\'ve exceeded', amt, 'cents.')
                game_over = True

        if game_over:
            ent = input('\nAnother go (y/n)?: ')

            if ent == 'n':
                terminate = True
print('Thanks for playing.  Later skater.')
