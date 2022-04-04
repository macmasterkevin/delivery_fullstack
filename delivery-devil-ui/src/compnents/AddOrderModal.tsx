import { FC, useCallback, useState } from 'react'
import { Button, InputNumber, Modal } from 'antd'


const AddOrderModal: FC<{
    open: boolean, 
    close: () => void
    onSave: (order: Order) => void
}> = ({
    onSave,
    open,
    close
}) => {
    const [amount, setAmount] = useState(3.50)

    const saveIt = useCallback(() => {
        onSave({
            collectionAmount: amount,
            customerId: 1,
            deliveryAddressId: 1,
            restaurantId: 1,
            orderId: 0,
            status: 0,
            tip: false,
        })
    }, [amount, onSave])

    return (
        <Modal
            visible={open}
            onCancel={close}
        >
            <h2>New Delivery</h2>
            <div style={{marginBottom: 20}}>
                For: Bilbo Baggins <br/>
            </div>
            <div style={{marginBottom: 20}}>
                <InputNumber onChange={value => setAmount(Number(value))} defaultValue={3.50} />
            </div>
            <div>
                <Button onClick={saveIt}>Add Delivery</Button>
            </div>
        </Modal>
    )
}

export default AddOrderModal