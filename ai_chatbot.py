# Simple AI Chatbot
print("Hello! I am your AI chatbot.")
user_input = input("How can I help you today? ")

if "hello" in user_input.lower():
    print("Hi there! How can I assist you?")
elif "your name" in user_input.lower():
    print("My name? i am just a chatbot")
else:
    print("I'm still learning. Let's explore AI together!")

