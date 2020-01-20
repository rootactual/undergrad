import datetime

# Meet and Greet
print('This program computes the approximate age in seconds of an ')
print('individual based on a provided date of brith.  Only dates of ')
print('birth from 1900 and after can be computed.\n')

#ask/get year month day from user
mb = int(input('Please enter the month you were born in (1-12): '))
db = int(input('Please enter the day of the month you were born (1~31): '))
yb = int(input('Please enter the year you were born in (4 digit number): '))

#access current date/time
cm = datetime.date.today().month
cd = datetime.date.today().day
cy = datetime.date.today().year

# 24hr/day 60m/hr 60s/min
nsecDay = 24 * 60 * 60
nsecYear= 365 * nsecDay

avg_nsecYear = ((4 * nsecYear) + nsecDay) // 4
avg_nsecMonth = avg_nsecYear // 12

#Calc Age apprx Seconds
nsec_1900_dob = (yb - (1900 * avg_nsecYear)) + \
                (mb - 1) * avg_nsecMonth + \
                (db * nsecDay)

nsec_1900_today = (cy - 1900 * avg_nsecYear) + \
                   (cm - 1 * avg_nsecMonth) + \
                   (cd * nsecDay)

ageSeconds = nsec_1900_dob - nsec_1900_today

print('\nYou are approximately', ageSeconds, 'seconds old.')
