package main

import "fmt"

func main(){
	var num1 int = 100
	switch num1 {
	case 88, 89:
		fmt.Println("Equal to 88 or 89")
	case 100:
		fmt.Println("Equal to 100")
	default:
		fmt.Printf("Not equal to 88, 89 or 100")
	}
}
