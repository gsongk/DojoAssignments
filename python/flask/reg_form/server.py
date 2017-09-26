from flask import Flask, render_template, request, redirect, session, flash
app = Flask(__name__)
# our index route will handle rendering our form
app.secret_key = "SecretKey"

@app.route('/')

def index():
    return render_template('index.html')