import { FC } from 'react'
import { useQuery, useQueryClient } from 'react-query'
import { addressToString } from '../tools/addressHelper'
import { Button, Popconfirm, Table } from 'antd'

const baseUrl = 'https://localhost:7139/restaurant'

const Restaurants: FC = () => {
    const queryClient = useQueryClient()
    const invalidate = () => queryClient.invalidateQueries("restaurants")

    const {isFetching, data}: {isFetching: boolean, data?: Restaurant[]} 
        = useQuery("restaurants", () => fetch(baseUrl).then(res => res.json()))

    const deleteRestaurant = (id: number) => {
        fetch(`${baseUrl}/${id}`, { method: 'DELETE'}).then(invalidate)
    }

    const columns = [
        {
            title: 'Name',
            dataIndex: 'name'
        },
        {
            title: 'Address',
            dataIndex: 'addressId',
            render: (_: string, value: Restaurant) => addressToString(value.address)
        },
        {
            title: '',
            dataIndex: '',
            render: (_: string, value: Restaurant) => (
                <Popconfirm 
                    title={`Are you sure you want to delete restaurant?`}
                    onConfirm={() => deleteRestaurant(value.restaurantId)}
                >
                    <Button type='text' danger>Delete</Button>
                </Popconfirm>)
        }
    ]

    return (
        <div>
            <Table
                columns={columns}
                dataSource={data}
                loading={isFetching}
            />
        </div>
    )
}

export default Restaurants