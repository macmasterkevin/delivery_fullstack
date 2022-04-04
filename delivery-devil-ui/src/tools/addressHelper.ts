
export const addressToString = (address?: Address) => address?.region && `${address.address1} ${address.city}, ${address.region.name}, ${address.postalCode}`