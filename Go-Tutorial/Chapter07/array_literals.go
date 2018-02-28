package main

import "fmt"

func main(){
	var arrKeyValue = [5]string{3:"Chris", 4:"Ron"}
	for i, val := range arrKeyValue{
		fmt.Printf("Person at %d is %s\n", i, val)
	}
}
