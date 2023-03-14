# BankCreditApp
To initialize this horrible monstrosity, slap it inside visual studio and then run it. Crude, yet effective (Not really).
# Classes:
# User
Mother class, other classes like General or Senior inherite it's variables and methods from it.
# Senior
Class that represents elderly people age 61 and older, gets it's variables from User class.
# General
Class that represents other people age 18 to 60, gets it's variables from User class.
# Other stuff:
# FileFramework
Static class that saves data to SaveData.dat file in your appdata folder and then loades it from there.
# Program
Class with static void Main(), which is crucial for initializing this project. Also has static Repository class for storage and Menu class for UI.
# Instruments
Static class that has many repeating code pieces like string formaters and testers.
#Thats all, folks!
