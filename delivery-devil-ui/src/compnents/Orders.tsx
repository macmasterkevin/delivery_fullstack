import { FC } from 'react'
import { useQuery, useQueryClient } from 'react-query'
import { addressToString } from '../tools/addressHelper'
import { CheckOutlined } from '@ant-design/icons'
import { Button, Popconfirm, Table } from 'antd'
import styled from 'styled-components'

const baseUrl = 'https://localhost:7139/order'

const Orders: FC = () => {
    const queryClient = useQueryClient()
    const invalidate = () => queryClient.invalidateQueries("orders")

    const {isFetching, data}: {isFetching: boolean, data?: Order[]} 
        = useQuery("orders", () => fetch(baseUrl).then(res => res.json()))

    const markDelivered = async (id: number, gaveTip: boolean) => {
        const url = `${baseUrl}/${id}/complete${gaveTip ? '?didTip=true' : ''}`
        fetch(url, { method: 'PATCH'}).then(invalidate)
    }

    const deleteOrder = (id: number) => {
        fetch(`${baseUrl}/${id}`, { method: 'DELETE'}).then(invalidate)
    }

    const columns = [
        {
            title: 'Customer',
            dataIndex: 'customerId',
            render: (_: string, value: Order) => (
                <div>
                    {value.customer?.name}<br />
                    @ {addressToString(value.deliveryAddress)}
                </div>)
        },
        {
            title: 'Restaurant',
            dataIndex: 'restaurantId',
            render: (_: string, value: Order) => (
                <div>
                    {value.restaurant?.name}<br />
                    @ {addressToString(value.restaurant?.address)}
                </div>)
        },
        {
            title: 'Amount',
            dataIndex: 'collectionAmount',
            render: (text: string) => `$ ${text}`
        },
        {
            title: 'Status',
            dataIndex: 'status',
            render: (text: string) => text == "0" ? "Order Placed"
                    : text == "1" ? "Out for Delivery" : "Completed"
        },
        {
            title: 'Tip',
            dataIndex: 'tip',
            render: (tip: string) => !!tip && <CheckOutlined />
        },
        {
            title: '',
            dataIndex: 'orderId',
            render: (_: string, value: Order) => value.status !== 2 && (
                <Popconfirm 
                    title={`Did ${value.customer?.name} give a tip?`}
                    onConfirm={() => markDelivered(value.orderId, true)}
                    onCancel={() => markDelivered(value.orderId, false)}
                    okText='Yes'
                    cancelText='No'
                >
                    <Button>Mark Delivered</Button>
                </Popconfirm>)
        },
        {
            title: '',
            dataIndex: '',
            render: (_: string, value: Order) => (
                <Popconfirm 
                    title={`Are you sure you want to delete order?`}
                    onConfirm={() => deleteOrder(value.orderId)}
                >
                    <Button type='text' danger>Delete</Button>
                </Popconfirm>)
        }
    ]

    return (
        <OrderTable>
            <Table
                columns={columns}
                dataSource={data}
                loading={isFetching}
            />
        </OrderTable>
    )
}

export default Orders

const OrderTable = styled.div`
    
`