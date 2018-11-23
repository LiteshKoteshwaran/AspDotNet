<!doctype html>
<html>
    <head>
        <style type="text/css">

            body {font-family:Arial, Sans-Serif;}

            #container {width:300px; margin:0 auto;}

            /* Nicely lines up the labels. */
            form label {display:inline-block; width:140px;}

            /* You could add a class to all the input boxes instead, if you like. That would be safer, and more backwards-compatible */
            form input[type="text"],
            form input[type="password"],
            form input[type="email"] {width:160px;}

            form .line {clear:both;}
            form .line.submit {text-align:right;}

        </style>
    </head>
    <body>
        <div id="container">
            <form>
                <h1>Entry your Course details</h1>
                <div class="line"><label for="username">Course Name *: </label><input type="text" id="username" /></div>
                <div class="line"><label for="pwd">Course ID*: </label><input type="number" id="pwd" /></div>
                <div class="line"><label for="ptc">Course Fee *: </label><input type="number" id="ptc" /></div>
                <div class="line submit"><input type="submit" value="Submit" /></div>

                <p>Note: Please make sure your details are correct before submitting form and that all fields marked with * are completed!.</p>
            </form>
        </div>
    </body>
</html>