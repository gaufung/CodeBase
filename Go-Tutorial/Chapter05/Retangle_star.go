package main

import "fmt"

func main(){
	for height:=0; height<10; height++{
		for width:=0; width<20;width++ {
			if width == 0 {
				fmt.Print("*")
			} else if width==19{
				fmt.Print("*\n")
			} else{

				if height == 0 || height == 9 {
					fmt.Printf("*")
				} else {
					fmt.Printf(" ")
				}
			}
		}
	}
}
