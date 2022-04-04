import { FC } from "react";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import styled from "styled-components";
import OrderView from "./Views/OrderView";
import RestaurantsView from './Views/RestaurantsView'


const AppRouter: FC = () => {
    return (
        <BrowserRouter>
            <header style={{fontSize: 20, marginBottom: '5%'}}>
                <SpacedLink to='/orders'>Orders</SpacedLink> | 
                <SpacedLink to='/restaurants'>Restaurants</SpacedLink> | 
                <SpacedLink to='/customers'>Customers</SpacedLink>
            </header>
            <Routes>
                <Route path='/restaurants' element={<RestaurantsView />} />
                <Route path='/orders' element={<OrderView />} />
                <Route path='/' element={<OrderView />} />
            </Routes>
        </BrowserRouter>
    )
}

export default AppRouter

const SpacedLink = styled(Link)`
    &&& {
        display: inline-block;
        margin: 0 20px;
        font-variant: small-caps;
    }
`