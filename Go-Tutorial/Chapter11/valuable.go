package main

import "fmt"

type stockPosition struct {
	ticker string
	sharePrice float32
	count float32
}


func (c stockPosition) getValue() float32 {
	return c.sharePrice * c.count
}

type car struct {
	make string
	model string
	price float32
}

func (c car) getValue() float32{
	return c.price
}

type valuable interface {
	getValue() float32
}

func showValue(asset valuable){
	fmt.Printf("asset value is %f\n", asset.getValue())
}

func main(){
	var o valuable = stockPosition{"GOOG", 577.4, 3}
	showValue(o)
	o = car{"BMW", "M3", 112.2}
	showValue(o)
}
