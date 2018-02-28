package main

import "fmt"


func split_2_strs(str string, idx int)(str1, str2 string){
	b := []byte(str)
	str1 = string(b[:idx])
	str2 = string(b[idx:])
	return
}

func main(){
	str := "gaofeng"
	str1, str2 := split_2_strs(str,4)
	fmt.Printf("The first part is %s, and next part %s", str1, str2)
}