import { Button, Col, Row, Typography } from 'antd'
import { FC, useState } from 'react'
import { useQueryClient } from 'react-query'
import AddRestaurantModal from '../compnents/AddRestaurantModal'
import Restaurants from '../compnents/Restaurants'

const baseUrl = 'https://localhost:7139/restaurant'

const RestaurantsView: FC = () => {
    const [addModalOpen, setAddModalOpen] = useState(false)

    const queryClient = useQueryClient()
    const invalidate = () => queryClient.invalidateQueries("restaurants")

    const addNew = (restaurant: Restaurant) => {
        fetch(`${baseUrl}`, { 
            method: 'POST',
            headers: new Headers({'content-type': 'application/json'}),
            body: JSON.stringify(restaurant),
        }).then(invalidate)
        .then(() => setAddModalOpen(false))
    }

    return (
        <div style={{margin: '10px 10%'}}>
            <Row justify='space-between'>
                <Col span={16} style={{textAlign: 'left'}}>
                    <Typography.Title level={2}>Restaurants</Typography.Title>
                </Col>
                <Col span={8} style={{textAlign: 'right'}}>
                    <Button onClick={() => setAddModalOpen(true)}>Add Restaurant</Button>
                </Col>
            </Row>
            <Row>
                <Col span={24}>
                    <Restaurants />
                </Col>
            </Row>
            <AddRestaurantModal 
                open={addModalOpen} 
                close={() => setAddModalOpen(false)}
                onSave={addNew} 
            />
        </div>
    )
}

export default RestaurantsView