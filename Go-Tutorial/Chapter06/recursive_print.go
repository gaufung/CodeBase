package main

import "fmt"

func main(){
	print(1)
}

func print(i int){
	if i == 10{
		fmt.Println(i)
	}else{
		print(i+1)
		fmt.Println(i)
	}
}
