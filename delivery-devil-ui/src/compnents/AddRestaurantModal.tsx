import { FC, useCallback, useState } from 'react'
import { Button, Input, Modal } from 'antd'


const AddRestaurantModal: FC<{
    open: boolean, 
    close: () => void
    onSave: (restaurant: Restaurant) => void
}> = ({
    onSave,
    open,
    close
}) => {
    const [name, setName] = useState('')

    const saveIt = useCallback(() => {
        onSave({
            addressId: 1,
            name,
            restaurantId: 0
        })
    }, [name, onSave])

    return (
        <Modal
            visible={open}
            onCancel={close}
        >
            <h2>New Restaurant</h2>
            <div style={{marginBottom: 20}}>
                <Input onChange={value => setName(value?.target?.value ?? '')} value={name}/>
            </div>
            <div>
                <Button onClick={saveIt}>Add Restaurant</Button>
            </div>
        </Modal>
    )
}

export default AddRestaurantModal