export class DbEntity{
    Id: number;
    IsDeleted : boolean;
    CreatedDateUTC : Date;
    UpdatedDateUTC: Date;
}

export class TodoItem  extends DbEntity {
    /**
     *
     */
    constructor(isEidt : boolean) {
        super();
        this.Id = 0;
    }
    Text : string;
    UserId : number;
    
}

