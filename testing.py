import string
def analyze_text(text):    
    # lets make the word count
    # word_dict = {}
    # cleaner = text.translate(str.maketrans("","",string.punctuation)).lower().split()

    # word_dict["word_count"] = (0)
    # word_dict["unique_word"] = len(set(cleaner))

    # word_counts = {}
    # print(word_dict)
    # for t in cleaner:
    #     word_dict["word_count"] += 1
    #     word_counts[t] = word_counts.get(t, 0) + 1
    # max_count = max(word_counts.values())
    # most_frequent = max(word_counts, key=word_counts.get)
    # # (f"{most_frequent}, {max_count}")
    # word_dict["most_frequent_word"] = set()
    # word_dict["most_frequent_word"].add(max_count)
    # word_dict["most_frequent_word"].add(most_frequent)
    # word_dict["most_frequent_word"] = (most_frequent, max_count)
        
    # print(word_dict)
    import string

def analyze_text(text):
    # Initialize dictionary
    word_dict = {}
    cleaner = text.translate(str.maketrans("", "", string.punctuation)).lower().split()

    # Store word count and unique words
    word_dict["word_count"] = len(cleaner)
    word_dict["unique_word"] = len(set(cleaner))

    # Count word frequencies
    word_counts = {}
    for word in cleaner:
        word_counts[word] = word_counts.get(word, 0) + 1

    # Find most frequent word
    max_count = max(word_counts.values())
    most_frequent = max(word_counts, key=word_counts.get)

    # Store results
    word_dict["most_frequent_word"] = (most_frequent, max_count)

    return word_dict  # ✅ Return instead of printing

# ✅ Test the function
text = "Python is fun! Python is powerful. Python is easy to learn."
result = analyze_text(text)
print(result)




def main():
    text = "Python is fun! Python is powerful. Python is easy to learn."
    analyze_text(text)

main()