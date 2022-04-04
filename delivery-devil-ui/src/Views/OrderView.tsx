import { Button, Col, Row, Typography } from 'antd'
import { FC, useState } from 'react'
import { useQueryClient } from 'react-query'
import AddOrderModal from '../compnents/AddOrderModal'
import Orders from '../compnents/Orders'

const baseUrl = 'https://localhost:7139/order'

const OrderView: FC = () => {
    const [addModalOpen, setAddModalOpen] = useState(false)

    const queryClient = useQueryClient()
    const invalidate = () => queryClient.invalidateQueries("orders")

    const addNew = (order: Order) => {
        fetch(`${baseUrl}`, { 
            method: 'POST',
            headers: new Headers({'content-type': 'application/json'}),
            body: JSON.stringify(order),
        }).then(invalidate)
        .then(() => setAddModalOpen(false))
    }

    return (
        <div style={{margin: '10px 10%'}}>
            <Row justify='space-between'>
                <Col span={16} style={{textAlign: 'left'}}>
                    <Typography.Title level={2}>Orders</Typography.Title>
                </Col>
                <Col span={8} style={{textAlign: 'right'}}>
                    <Button onClick={() => setAddModalOpen(true)}>Add Order</Button>
                </Col>
            </Row>
            <Row>
                <Col span={24}>
                    <Orders />
                </Col>
            </Row>
            <AddOrderModal 
                open={addModalOpen} 
                close={() => setAddModalOpen(false)}
                onSave={addNew} 
            />
        </div>
    )
}

export default OrderView