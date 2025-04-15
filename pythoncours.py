import string
def multi_word_search(doc_list, keywords):
    """
    Takes list of documents (each document is a string) and a list of keywords.  
    Returns a dictionary where each key is a keyword, and the value is a list of indices
    (from doc_list) of the documents containing that keyword

    >>> doc_list = ["The Learn Python Challenge Casino.", "They bought a car and a casino", "Casinoville"]
    >>> keywords = ['casino', 'they']
    >>> multi_word_search(doc_list, keywords)
    {'casino': [0, 1], 'they': [1]}
    """
    #1. take list of doc_list and a list of keyword
    # list_keyword = [k.lower() for k in keywords]
    # result_dict = {}
    # count_key = 0
    # list_doc = [(i, doc.lower()) for i, doc in enumerate(doc_list)]
    # keyword_list = set()  # ✅ This will store unique indices

    # for i, doc in list_doc:
    #     print(f"this is the index:{i} and this is the string: {doc}")
    
    # for key in list_keyword:
    #     if key in doc:  # ✅ Corrected condition
    #         keyword_list.add(i)  # ✅ Use .add() to avoid duplicates
    # print(list(keyword_list))
    
    # for key in result_dict:
    #     result_dict[key] = list(result_dict[key])

    # print(result_dict)


    


    # result_dict = {}

    # for key in keywords:  
    #     result_dict[key] = set()  

    # for i, doc in enumerate(doc_list):  
    #     words = doc.translate(str.maketrans("", "", string.punctuation)).lower().split()
    #     for key in keywords:
    #         if key in words:  
    #             result_dict[key].add(i)  

    # for key in result_dict:
    #     result_dict[key] = list(result_dict[key])

    # print(result_dict)  


    

    # for key in result_dict:
    #     result_dict[key] = list(result_dict[key])
    # print(list(result_dict))


    #2. return a dictionary where {(key)keyword: indices(value)} from doc_list
    # doc_dict = {keyword: list_doc for keyword in keywords}
    # print(doc_dict)





def main():
    doc_list = ["The Learn Python Challenge Casino.", "They bought a car and a casino", "Casinoville"]
    keywords = ['casino', 'they']
    multi_word_search(doc_list, keywords)


main()