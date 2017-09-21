#Import Flask to allow us to create our app
from flask import Flask, render_template

#Global variable __name__ tell Flask whether or not we are running the file
#directly or importing it as a module
app = Flask(__name__)

#The "@" symbol designates a "decorator" which attaches the following
#function the "/" route. This means that when ever we send a request to
#localhost:5000/ we will run the following "hello_world" function.
@app.route('/')
# #Return "Hello world!" to the response.
def hello_world():
    return render_template('index.html', phrase='Hello', times=5)

@app.route('/success')
def success():
    return render_template('success.html')

#Run the app in the debug mode.
app.run(debug=True)