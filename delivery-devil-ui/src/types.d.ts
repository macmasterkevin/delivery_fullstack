interface Order {
    orderId: number;
    deliveryAddressId: number;
    customerId: number;
    restaurantId: number;
    collectionAmount: number;
    status: number;
    tip: boolean;
    createdDate?: string;

    customer?: Customer;
    restaurant?: Restaurant;
    deliveryAddress?: Address;
}

interface Customer {
    customerId: number;
    name: string;
    defaultAddressId: number;

    defaultAddress?: Address;
}

interface Restaurant {
    restaurantId: number;
    name: string;
    addressId: number;

    address?: Address;
}

interface Address {
    address1: string;
    city: string;
    regionId: number;
    postalCode: string;

    region?: Region
}

interface Region {
    regionId: number;
    name: string;
    countryId: number;

    country?: Country;
}

interface Country {
    countryId: number;
    name: string;
}