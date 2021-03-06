package main

import (
	"net/http"
	"io"
)

const form = `
	<html>
		<body>
			<form action="#" method="post" name="bar">
				<input type="text" name="in"/>
				<input type="submit" value="submit"/>
			</form>
		</body>
	</html>
`

func simpleServer(w http.ResponseWriter, request *http.Request){
	io.WriteString(w, "<h1>Hello world</h1>")
}

func formServer(w http.ResponseWriter, request *http.Request){
	w.Header().Set("Content-Type", "text/html")
	switch request.Method {
	case "GET":
		io.WriteString(w, form)
	case "POST":
		io.WriteString(w, request.FormValue("in"))
	}
}

func main(){
	http.HandleFunc("/test1", simpleServer)
	http.HandleFunc("/test2", formServer)
	if err := http.ListenAndServe(":8080", nil); err !=nil{
		panic(err)
	}
}