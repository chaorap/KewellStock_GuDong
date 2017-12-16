from flask import Flask, render_template, request
from flask import jsonify

#refer
# http://blog.csdn.net/a475952074/article/details/76736887

app = Flask(__name__)
app.config['SECRET_KEY'] = "dfdfdffdad"

@app.route('/')
def index():
    #return render_template('index.html')
    return "index"

@app.route('/signin', methods=['GET'])
def signin_form():
    return '''<form action="/signin" method="post">
              <p><input name="username"></p>
              <p><input name="password" type="password"></p>
              <p><button type="submit">Sign In</button></p>
              </form>'''

@app.route('/signin', methods=['POST'])
def signin():
    # 需要从request对象读取表单内容：
    if request.form['username']=='admin' and request.form['password']=='password':
        return '<h3>Hello, admin!</h3>'
    return '<h3>Bad username or password.</h3>'              

if __name__ == '__main__':
    app.run(
        host = '0.0.0.0',
        port = 7777,  
        debug = False 
    )