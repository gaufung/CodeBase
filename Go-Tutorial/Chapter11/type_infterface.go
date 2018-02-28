package main

import (
	"fmt"
)

type shape interface {
	perimeter() float32
}

type circle struct {
	radius float32
}

type square struct {
	side float32
}

func (c circle) perimeter() float32{
	return 3.14 * c.radius * c.radius
}

func (s square) perimeter() float32 {
	return s.side * s.side
}

func main(){
	var areInf  shape
	c1 :=new(circle)
	c1.radius = 2.0

	areInf = c1
	if t, ok := areInf.(*circle); ok{
		fmt.Printf("the type of areInf is %T\n", t)
	}
	if u, ok := areInf.(circle); ok{
		fmt.Printf("the type of areInf is %T\n", u)
	}else{
		fmt.Println("the areinf is not circle")
	}

}
