class MessageController < Controller
  
  def index
    
    message = Message.new
    @model = message
    view nil, 'layout'
  end
end