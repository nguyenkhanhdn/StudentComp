import pandas as pd
import numpy as np
import pyodbc

from sklearn.feature_extraction import text
from sklearn.metrics.pairwise import cosine_similarity

'''
sql
'''
server = '(local)\sqlexpress'
database = 'studentcomp' 
username = 'sa'
password = '123456'
cnxn = pyodbc.connect('DRIVER={SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password)
cursor = cnxn.cursor()
# select 26 rows from SQL table to insert in dataframe.
query = "SELECT id, [brief], [content],[createdDate],[hit] FROM Handbooks"
data = pd.read_sql(query, cnxn)
#print(df.head(26))


#data = pd.read_csv("articles.csv", encoding="latin1")
#data.head() https://raw.githubusercontent.com/amankharwal/Website-data/master/
articles = data["content"].tolist()
uni_tfidf = text.TfidfVectorizer(input=articles, stop_words="english")
uni_matrix = uni_tfidf.fit_transform(articles)
uni_sim = cosine_similarity(uni_matrix)

def recommend_articles(x):
    return "; ".join(data["brief"].loc[x.argsort()[-5:-1]])

data["recommend"] = [recommend_articles(x) for x in uni_sim]
x = data.head(10)
#x = data
print(x.iloc[:,3])

cursor.execute("delete from recommends")
cnxn.commit()

for index, row in x.iterrows():
     cursor.execute("INSERT INTO Recommends(HandbookId,title,[RecommendArticle],createdDate,hit) values(?,?,?,?,?)",
                    row.id, row.brief, row.recommend, row.createdDate, row.hit)
cnxn.commit()
print('Finish')
