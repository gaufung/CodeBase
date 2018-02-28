package main

import "fmt"

func main() {
	k := 5
	switch k {
	case 4:
		fmt.Println("was <= 4")
		fallthrough
	case 5:
		fmt.Println("was <= 5")
		fallthrough
	case 6:
		fmt.Println("was <= 6")
		fallthrough
	default:
		fmt.Println("default case")
	}
}
