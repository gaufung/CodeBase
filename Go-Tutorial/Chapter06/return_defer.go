package main

import "fmt"

func f3() (ret int){
	defer func() {
		ret++
	}()
	return 1
}

func main(){
	fmt.Println(f3())
}