import React from 'react'
import { Switch, Route} from 'react-router-dom'
import Register from './Sections/Register'
import ItemsList from './Sections/Products/ItemsList'
import Cart from './Sections/Cart/Cart'
import AddProduct from './Sections/AddProduct'

class Main extends React.Component {

    state = {
        isLoggedIn: null,
        token: null,
        userModel: []
    }

    render(){
return(

        <Switch>
            <Route path="/" exact component={ () => <ItemsList
                                                        products={this.props.products}
                                                        addToCart={this.props.addToCart}
                                                        UserRole={this.props.UserRole}
                                                        deleteProduct={this.props.deleteProduct}
            />}/>
            <Route path="/Register" component={ () => <Register
                                                        register = {this.props.register}
                                                        errors={this.props.errors}
                                                        removeErrors={this.props.removeErrors}
            />}/>
            <Route path="/AddProduct" component={ () => <AddProduct
                                                        increaseNumberOfProducts={this.props.increaseNumberOfProducts}
                                                        loadNewListOfProducts={this.props.loadNewListOfProducts}
            />}/>
            <Route path="/Cart" component={ () => <Cart
                                                        completeOrder={this.props.completeOrder}
                                                        OrderId={this.props.OrderId}
                                                        decreaseQuantityOfProductsInCart={this.props.decreaseQuantityOfProductsInCart}
            />}/>
        </Switch>

)
}
}
export default Main